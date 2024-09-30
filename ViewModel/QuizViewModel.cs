using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class QuizViewModel
    {
        public int QuizID { get; set; }
        public string Question { get; set; }
        
        public ICollection<QuizOptionViewModel> Options { get; set; }

        public QuizOptionViewModel CorrectOption { get; set; }

        public QuizViewModel()
        {
            Options = new List<QuizOptionViewModel>();
            CorrectOption = new ();
        }
    }
}
