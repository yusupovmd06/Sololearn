using Sololearn.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.utils
{
    public static class EnumExtensions
    {
        public static QuestionType GetQuestionType(this string type)
        {
            foreach (QuestionType type1 in Enum.GetValues(typeof(QuestionType))){
                if (type1.ToString().Equals(type))
                    return type1;
            }
            return QuestionType.TEST;
        }
    }
}
