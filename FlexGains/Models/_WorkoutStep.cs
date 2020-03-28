using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlexGains.Models
{
    [MetadataType(typeof(WorkoutStepAnnotations))]
    public partial class WorkoutStep
    {
    }
    
    public class WorkoutStepAnnotations
    {
        public int StepId { get; set; }
        public Nullable<int> WorkoutId { get; set; }
        [Required]
        public Nullable<int> ExerciseId { get; set; }
        public Nullable<byte> WorkoutOrder { get; set; }
        [Required]
        public Nullable<int> RepsNumber { get; set; }
        [Required]
        public Nullable<int> SetsNumber { get; set; }
    }
}