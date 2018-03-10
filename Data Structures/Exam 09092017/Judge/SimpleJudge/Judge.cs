using System;
using System.Collections.Generic;
using System.Linq;

public class Judge : IJudge
{
    private HashSet<int> userIds;
    private HashSet<int> contestIds;
    private Dictionary<int, Submission> submissions;

    public Judge()
    {
        this.userIds = new HashSet<int>();
        this.contestIds = new HashSet<int>();
        this.submissions = new Dictionary<int, Submission>();
    }

    public void AddContest(int contestId)
    {
        this.contestIds.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        if (!this.userIds.Contains(submission.UserId))
        {
            throw new InvalidOperationException();
        }

        if (!this.contestIds.Contains(submission.ContestId))
        {
            throw new InvalidOperationException();
        }

        if (!this.submissions.ContainsKey(submission.Id))
        {
            this.submissions.Add(submission.Id, submission);
        }
    }

    public void AddUser(int userId)
    {
        this.userIds.Add(userId);
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!this.submissions.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }

        this.submissions.Remove(submissionId);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.submissions.OrderBy(x => x.Key).Select(x => x.Value);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.userIds.OrderBy(x => x);
    }

    public IEnumerable<int> GetContests()
    {
        return this.contestIds.OrderBy(x => x);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return this.submissions.Values.Where(s =>
            s.Type == submissionType && minPoints <= s.Points && maxPoints >= s.Points);
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        if (!this.userIds.Contains(userId))
        {
            throw new InvalidOperationException();
        }

        return this.submissions.Values.Where(s => s.UserId == userId).OrderByDescending(s => s.Points).ThenBy(s => s.Id).Select(s => s.ContestId).Distinct();
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        if (!this.userIds.Contains(userId))
        {
            throw new InvalidOperationException();
        }

        if (!contestIds.Contains(contestId))
        {
            throw new InvalidOperationException();
        }

        if (this.submissions.Values.Where(s => s.Points == points).Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return this.submissions.Values.Where(s =>
            s.ContestId == contestId && s.UserId == userId && s.Points == points);
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        return this.submissions.Values
            .Where(x => x.Type == submissionType)
            .Select(x => x.ContestId)
            .Distinct();
    }
}
