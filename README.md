# Bedside Status Service — SPARK TSL Practical Assignment

A deliberately imperfect sample of the kind of service we run: a small API that
tells a patient's bedside unit which content channels are available.

Full instructions are in the assignment brief. Summary — **time-box: ~2 hours
total.** Prioritisation is the test; unfinished is expected.

1. **Review & fix (~45 min).** The Dockerfile, compose file and code contain
   choices we would not accept in production. Find them, rank them, and fix
   ONLY the top three you would never let reach production. Commit the fixes.
2. **One small code change (~30 min).** Add health endpoint(s) suitable for a
   load-balancer / orchestrator health check (a liveness/readiness split is
   welcome), and make the logging structured.
3. **Pipeline sketch (~30 min).** A `bitbucket-pipelines.yml` (GitHub Actions
   fine) at skeleton level — real stage names and named tools for build, test,
   scan, deploy to AWS ECS Fargate, rollback. It does NOT need to run; it
   needs to show how you think. No Terraform required — note in comments what
   infra it assumes.
4. **NOTES.md (~15 min),** four short sections:
   - (a) issues you found but chose NOT to fix, ranked, one line each
   - (b) hospital twist, max 5 bullets: this must also run on a small on-prem
     box — no inbound access, monthly 4-hour change window, a site network
     you don't control. What changes?
   - (c) one paragraph: an NHS Trust asks "what changed in production last
     month, who approved it, prove it" — answer from your pipeline sketch
   - (d) one real AI example from your prep: prompt → output → what you
     changed. If you used none, say so and why.

**Work in git, submit the history.** This pack ships as a git repository with
a single baseline commit (tagged `baseline`) — build your history on top of
it with small, logical commits whose messages explain *why*, not just *what*.
Your commit history is part of the assessment: it shows how you approached
the problem, in what order, and what you reconsidered. We diff your work
against `baseline`. Submit as a repository link (preferred) or a zip that
INCLUDES the `.git` folder, 24h before the interview.

Be ready to drive a ~10-minute walkthrough of your repo on a screen share.
AI assistance is explicitly welcome; you must be able to defend every line.
Run locally: `dotnet run --project src/BedsideStatus` then
`curl http://localhost:5000/channels`.
