using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlexGains.Models
{
    public partial class Workout
    {
        public WorkoutClass GetType()
        {
            if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Bicep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Tricep")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Arm;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Bicep"))
            {
                return WorkoutClass.Bicep;
            }
            else if ((this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest")
                || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps"))&& this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
                && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.ChestAndTri;
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Bicep")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Abdominals")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Obliques")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps"))
            {
                return WorkoutClass.BackAndBi;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Tricep"))
            {
                return WorkoutClass.Tricep;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Back"))
            {
                return WorkoutClass.Back;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Chest"))
            {
                return WorkoutClass.Chest;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Back") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Bicep")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Chest") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Chest/Triceps")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Tricep") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Abdominals")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Legs") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Obliques")
               && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "FullBody") && this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Back/Biceps"))
            {
                return WorkoutClass.Abdominals;

            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Abdominals"))
            {
                return WorkoutClass.Abdominals;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Obliques"))
            {
                return WorkoutClass.Obliques;
            }
            else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName != "Legs"))
            {
                if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest"))
                {
                    return WorkoutClass.UpperBody;
                }
                else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps"))
                {
                    return WorkoutClass.UpperBody;
                }
                else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest"))
                {
                    return WorkoutClass.UpperBody;
                }
                else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") && this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps"))
                {
                    return WorkoutClass.UpperBody;
                }
                else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Abdominals") && (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps")
                    || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest")
                    || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Triceps") || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Biceps")
                    || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps")))
                {
                    return WorkoutClass.UpperBody;
                }
                else
                {
                    return WorkoutClass.Custom;
                }
            }
            else if (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Legs"))
            {
                if ((this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back") || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps")
                || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Back/Biceps")) && (this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest/Triceps")
                || this.WorkoutSteps.Any(s => s.Exercise.MuscleGroup.GroupName == "Chest")))
                    {
                    return WorkoutClass.FullBody;
                    }
                else if (this.WorkoutSteps.All(s => s.Exercise.MuscleGroup.GroupName == "Legs"))
                {
                    return WorkoutClass.Legs;
                }
                else
                {
                    return WorkoutClass.Custom;
                }
            }
            else
            {
                return WorkoutClass.Custom;
            }
        }
    }
    public enum WorkoutClass 
    {
        Custom, 
        Arm, 
        Bicep, 
        [Display(Name ="Back/Biceps")]
        BackAndBi, 
        Tricep,
        [Display(Name = "Chest/Triceps")]
        ChestAndTri, 
        Chest, 
        Back, 
        Abdominals, 
        Legs,
        [Display(Name = "Full Body")]
        FullBody, 
        Obliques,
        [Display(Name = "Upper Body")]
        UpperBody
    }

}