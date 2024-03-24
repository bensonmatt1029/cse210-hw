using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

EternalQuestProgram program = new EternalQuestProgram();

program.AddGoal(new SimpleGoal("Run a marathon", 1000, 0));
program.AddGoal(new EternalGoal("Read scriptures", 100, 0));
program.AddGoal(new ChecklistGoal("Attend the temple", 50, 10, 500));

program.RecordEvent(0);  // Mark "Run a marathon" as complete
program.RecordEvent(1);  // Mark "Read scriptures" as complete
program.RecordEvent(2);  // Mark "Attend the temple" as complete

program.DisplayScore();  // Display the total score
program.DisplayGoals();  // Display all goals

program.SaveGoals("goals.json");  // Save goals to a file

// Load saved goals
EternalQuestProgram program2 = new EternalQuestProgram();
program2.LoadGoals("goals.json");
program2.DisplayGoals();  // Display loaded goals
