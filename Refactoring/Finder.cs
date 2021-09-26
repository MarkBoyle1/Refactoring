using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring
{
    public class Finder
    {
        private List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Comparison Find(AgeGap ageGapComparison)
        {
            _people = _people.OrderBy(person => person.BirthDate).ToList();

            if (_people.Count < 2)
            {
                return GetZeroGapComparison();
            }
            
            return ageGapComparison == AgeGap.LargestAgeGap ? GetLargestGapComparison() : GetSmallestGapComparison();
        }
        
        private Comparison GetZeroGapComparison()
        {
            return new Comparison()
            {
                Person1 = null,
                Person2 = null
            };
        }

        private Comparison GetLargestGapComparison()
        {
           return new Comparison()
            {
                Person1 = _people[0],
                Person2 = _people[_people.Count - 1],
                AgeGap = _people[0].BirthDate - _people[_people.Count - 1].BirthDate
            };
        }

        private Comparison GetSmallestGapComparison()
        {
            Person smallestGapPerson1 = _people[0];
            Person smallestGapPerson2 = _people[1];
            TimeSpan smallestGap = _people[1].BirthDate - _people[0].BirthDate;
            
            //Iterates through people list to find the smallest gap.
            for (int i = 2; i < _people.Count; i++)
            {
                Person p1 = _people[i - 1];
                Person p2 = _people[i];
                
                if (p2.BirthDate - p1.BirthDate < smallestGap)
                {
                    smallestGap = p2.BirthDate - p1.BirthDate;
                    smallestGapPerson1 = p2;
                    smallestGapPerson2 = p1;
                }
            }
            
            return new Comparison()
            {
                Person1 = smallestGapPerson1,
                Person2 = smallestGapPerson2,
                AgeGap = smallestGap
            };
        }
    }
}