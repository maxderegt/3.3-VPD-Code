using System.Collections.Generic;

public class Results
{
    public string Name;
    public List<string> StepsRequired = new List<string>();
    public List<string> StepsTaken = new List<string>();
    public List<string> ExtraSteps = new List<string>();
    public bool AllRequiredSteps;

    public Results(string name, List<ResearchMethods> stepsRequired, List<ResearchMethods> stepsTaken)
    {
        Name = name;

        foreach (ResearchMethods item in stepsRequired)
        {
            StepsRequired.Add(item.ToString());
        }
        bool completed = true;
        foreach (ResearchMethods item in stepsTaken)
        {
            StepsTaken.Add(item.ToString());
            if (!stepsRequired.Contains(item))
            {
                ExtraSteps.Add(item.ToString());
                completed = false;
            }
        }
        AllRequiredSteps = completed;
    }
}
