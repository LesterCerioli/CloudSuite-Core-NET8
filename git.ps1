# Fetch the work item ID associated with the pull request
$workItemId = az boards work item show --id <PULL_REQUEST_ID> --query id --output tsv

# Check if work item ID is retrieved successfully
if (-not $workItemId) {
    Write-Host "Failed to retrieve the work item ID associated with the pull request."
    exit 1
}

# Set the work item ID as the BUILD_PULLREQUEST_ID environment variable
$env:BUILD_PULLREQUEST_ID = $workItemId
Write-Host "BUILD_PULLREQUEST_ID set to: $workItemId"

# Fetch the PR's commits
git fetch origin refs/pull/$env:BUILD_PULLREQUEST_ID/merge

# Extract commit messages
$commitMessages = git log --format=%s refs/pull/$env:BUILD_PULLREQUEST_ID/merge

# Check if any semantic commits are found
$semanticCommitFound = $false
foreach ($message in $commitMessages) {
    if ($message -match '^((feat|fix|docs|style|refactor|perf|test|chore)(\([^()]+\))?: .{1,})(\n|$)') {
        $semanticCommitFound = $true
        break
    }
}

# If no semantic commits are found, block the PR
if (-not $semanticCommitFound) {
    Write-Host "PR sem requisitos de aceitação."
    exit 1
} else {
    Write-Host "PR recebido com sucesso."
}
