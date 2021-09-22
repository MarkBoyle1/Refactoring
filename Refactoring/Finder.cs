using System.Collections.Generic;

namespace Refactoring
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Comparison Find(AgeGap ft)
        {
            var listOfComparisons = new List<Comparison>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var newComparison = new Comparison();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        newComparison.Person1 = _people[i];
                        newComparison.Person2 = _people[j];
                    }
                    else
                    {
                        newComparison.Person1 = _people[j];
                        newComparison.Person2 = _people[i];
                    }
                    newComparison.AgeGap = newComparison.Person2.BirthDate - newComparison.Person1.BirthDate;
                    listOfComparisons.Add(newComparison);
                }
            }

            if(listOfComparisons.Count < 1)
            {
                return new Comparison();
            }

            Comparison answer = listOfComparisons[0];
            foreach(var result in listOfComparisons)
            {
                switch(ft)
                {
                    case AgeGap.SmallestAgeGap:
                        if(result.AgeGap < answer.AgeGap)
                        {
                            answer = result;
                        }
                        break;

                    case AgeGap.LargestAgeGap:
                        if(result.AgeGap > answer.AgeGap)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}