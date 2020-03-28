using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexGains.Models
{
    public class MuscleGroupSelectionViewModel
    {
        public WorkoutClass groupId { get; set; }
        public IEnumerable<Workout> workouts { get; set; }

    }
}