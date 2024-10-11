```markdown
# CrossPlatformLabs

## Running the Lab

To run, build, or test the labs, use the following commands. Make sure to run these commands from the **root** of the repository:

### Run the Lab:
```bash
dotnet build Build.proj -t:Run -p:Solution=Lab1
```

### Build the Lab:
```bash
dotnet build Build.proj -t:Build -p:Solution=Lab1
```

### Run Tests:
```bash
dotnet build Build.proj -t:Test -p:Solution=Lab1
```

Replace `Lab1` with `Lab2` for Lab #2, `Lab3` for Lab #3, etc.

---

## Lab Structure

Each lab has its own folder:

- Lab1
- Lab2
- Lab3

---

## MSBuild Usage

We use an MSBuild project file (`Build.proj`) to manage the build, test, and run processes. You should execute all commands from the root of the repository to ensure the correct behavior of the MSBuild scripts. Replace the `Solution` parameter with the specific lab folder (e.g., Lab1, Lab2) to target the correct lab.
```