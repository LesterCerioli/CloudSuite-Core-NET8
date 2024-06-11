# Get the title of the pull request
$pullRequestTitle = az repos pr show --id <PULL_REQUEST_ID> --query title --output tsv

# Check if the title matches the semantic commit format
if ($pullRequestTitle -notmatch '^(feat|fix|docs|style|refactor|perf|test|chore)(\([^()]+\))?: .{1,}$') {
    Write-Host "The title of the pull request does not match the semantic commit format."
    exit 1
} else {
    Write-Host "The title of the pull request matches the semantic commit format."
}
