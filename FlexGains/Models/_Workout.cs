using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexGains.Models
{
    public partial class Workout
    {
        public WorkoutClass GetType()
        {

            if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Bicep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Tricep")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Arm;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Bicep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Bicep;
            }
            else if ((this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest")
                || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps"))&& this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.ChestAndTri;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps"))
            {
                return WorkoutClass.BackAndBi;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Tricep;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Back;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Chest;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Legs;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Abdominals;

            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Abdominals;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Obliques")
               && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Obliques;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest")
                && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName != "Legs"))
            {
                return WorkoutClass.UpperBody;
            }
            else if ((this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps")
                || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps")) && (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps")
                || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest")) && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Legs"))
            {
                return WorkoutClass.FullBody;
            }
            else
            {
                return WorkoutClass.Unknown;
            }
        }
    }
    public enum WorkoutClass {Unknown, Arm, Bicep, BackAndBi, Tricep, ChestAndTri, Chest, Back, Abdominals, Legs, FullBody, Obliques, UpperBody}

}