Original code done with Framework 4.7.2 and instead of attempting to convert the existing code to .NET Core a new class project was created, code from current .NET Framework 4 was pasted into the new project. Next a separate unit test project was created to test the new .NET Core project.

Using the above if something went wrong the original code remains in tact. Way too many developers will

:x: Not use source control hence bad code cannot be reverted

:heavy_check_mark: Always use source control to revert changes

Using source control in this case on both projects keeps working code safe.

:x: Do not wait hours to commit

:heavy_check_mark: Commit often with good comments on each commit.


![img](assets/Figure1.png)

Always test!!!

![Figure2](assets/figure2.png)