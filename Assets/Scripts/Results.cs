using System.Collections.Generic;

public class Results
{
    public string Name; //name of the evidence
    public List<string> StepsRequired = new List<string>(); //list of all the steps required
    public List<string> StepsTaken = new List<string>(); //list of all the steps taken
    public List<string> ExtraSteps = new List<string>(); //list of all the extra steps taken
    public bool AllRequiredSteps; //boolean if all required steps are taken


    //converts everything to strings and checks if all steps are taken/extra steps are taken
    public Results(string name, List<ResearchMethods> stepsRequired, List<ResearchMethods> stepsTaken)
    {
        Name = name;
        foreach (ResearchMethods item in stepsTaken)
        {
            StepsTaken.Add(item.ToString());
            if (!stepsRequired.Contains(item))
            {
                ExtraSteps.Add(item.ToString());
            }
        }
        bool completed = true;
        foreach (ResearchMethods item in stepsRequired)
        {
            StepsRequired.Add(item.ToString());
            if (!stepsTaken.Contains(item))
            {
                completed = false;
            }
        }
        
        AllRequiredSteps = completed;
    }
}
