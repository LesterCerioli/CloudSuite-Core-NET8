# Fetch the PR's commits
git fetch origin refs/pull/$(Build.PullRequestId)/merge

# Extract commit messages
$commitMessages = git log --format=%s refs/pull/$(Build.PullRequestId)/merge

# Check each commit message against the semantic commit format
$invalidMessages = 0
foreach ($message in $commitMessages) {
    if ($message -notmatch '^((feat|fix|docs|style|refactor|perf|test|chore)(\([^()]+\))?: .{1,})(\n|$)') {
        Write-Host "Invalid semantic commit message format: $message"
        Write-Host "Commit message format should be: '<type>(<scope>): <description>'"
        Write-Host "Please fix the commit message and try again."
        $invalidMessages++
    }
}

# Fail the script if any invalid messages are found
if ($invalidMessages -gt 0) {
    exit 1
}
