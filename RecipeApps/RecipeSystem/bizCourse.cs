using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizCourse: bizObject<bizCourse>
    {
        public bizCourse()
        {

        }

        private int _courseId;
        private string _coursename;
        private int _sequenceorder;

        public int CourseId
        {
            get { return _courseId; }
            set
            {
                if (_courseId != value)
                {
                    _courseId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string CourseName
        {
            get { return _coursename; }
            set
            {
                if (_coursename != value)
                {
                    _coursename = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int SequenceOrder
        {
            get { return _sequenceorder; }
            set
            {
                if (_sequenceorder != value)
                {
                    _sequenceorder = value;
                    InvokePropertyChanged();
                }
            }
        }
    }

}
