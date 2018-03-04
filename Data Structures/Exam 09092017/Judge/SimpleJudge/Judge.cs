using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Judge : IJudge
{
    private OrderedSet<int> userIds;
    private OrderedSet<int> contestIds;
    private Dictionary<int, Submission> submissions;

    public Judge()
    {
        this.userIds = new OrderedSet<int>();
        this.contestIds = new OrderedSet<int>();
        this.submissions = new Dictionary<int, Submission>();
    }

    public void AddContest(int contestId)
    {
        contestIds.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        if (!userIds.Contains(submission.UserId))
        {
            throw new InvalidOperationException();
        }

        if (!contestIds.Contains(submission.ContestId))
        {
            throw new InvalidOperationException();
        }

        if (!submissions.ContainsKey(submission.Id))
        {
            submissions.Add(submission.Id, submission);
        }
    }

    public void AddUser(int userId)
    {
        userIds.Add(userId);
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!submissions.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }

        submissions.Remove(submissionId);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return submissions.OrderBy(x => x.Key).Select(x => x.Value);
    }

    public IEnumerable<int> GetUsers()
    {
        return userIds;
    }

    public IEnumerable<int> GetContests()
    {
        return contestIds;
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return submissions.Values.Where(s =>
            s.Type == submissionType && minPoints <= s.Points && maxPoints >= s.Points);
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        if (!userIds.Contains(userId))
        {
            throw new InvalidOperationException();
        }

        return submissions.Values.Where(s => s.UserId == userId).OrderByDescending(s => s.Points).ThenBy(s => s.Id).Select(s => s.ContestId).Distinct();
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        if (!userIds.Contains(userId))
        {
            throw new InvalidOperationException();
        }

        if (!contestIds.Contains(contestId))
        {
            throw new InvalidOperationException();
        }

        if (submissions.Values.Where(s => s.Points == points).Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return submissions.Values.Where(s =>
            s.ContestId == contestId && s.UserId == userId && s.Points == points);
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        return submissions.Values.Where(s => s.Type == submissionType).Select(s => s.ContestId).Distinct();
    }
}
