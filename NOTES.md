#Notes
#A. Issues found but not prioritized during the initial review

1. Medium — No authentication/authorization; not fixed because no authentication requirements were specified.
2. Medium — Application still uses Debug configuration; deprioritized against higher-impact production risks.
3. Low — No `.dockerignore`; deprioritized as a lower-impact build-context issue.
4. Low — `Console.WriteLine` with `DateTime.Now`; deferred to Task 2 and later replaced with structured `ILogger` logging.
5. Medium — `sdk:latest` was initially deprioritized; later pinned to `8.0` after testing exposed a .NET version mismatch.
6. Low — Channel data remains hardcoded in memory; database implementation was outside the assignment scope.



#B. On-premises hospital deployment
* Deploy only during the approved monthly 4-hour change window to avoid unplanned production changes.
* Test and security-scan the container image before the change window, so deployment can be completed quickly.
* Keep the last known-good container image locally so we can roll back quickly if the new version fails.
* Keep configuration and secrets stored securely on-premises, so the service does not depend on cloud services being available.
* Add timeouts and retry mechanisms for network-dependent operations because the hospital network is outside our control.



#C. Production change audit

If an NHS Trust asks what changed in production last month, I would use the Git commit history and the commit ID linked to each deployed container image to identify the exact code changes. GitHub pull request history and the production environment approval would show who reviewed and approved the change. The GitHub Actions workflow logs would show when the build, tests, security scan and deployment were performed, while the ECR image tag and ECS task definition revision would confirm the exact version deployed to production. These records together provide an audit trail showing what changed, who approved it, when it was deployed and what actually ran in production.


#D. AI usage

I had not worked with .NET before, so I used ChatGPT to help me understand the existing `Program.cs` before making changes. I asked, "Can you explain how configuration and logging work in this .NET application and how I can remove the hardcoded values?"

ChatGPT explained that .NET has a built-in configuration system that can read environment variables and that `ILogger` can be used for structured logging instead of `Console.WriteLine`. Based on this, I changed the hardcoded configuration to use `builder.Configuration` and replaced the console logging with structured `ILogger` messages. I tested the application in Docker after the changes to verify that the configuration was read correctly and the logging still worked.
