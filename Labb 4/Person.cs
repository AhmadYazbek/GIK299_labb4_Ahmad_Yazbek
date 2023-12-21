using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public Hair Hair { get; private set; }
        public DateTime Birthday { get; private set; }
        public string EyeColour { get; private set; }





        public Person(string firstname, string lastname, Gender gender, Hair hair, DateTime birthday, string eyecolour)
        {
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            Hair = hair;
            EyeColour = eyecolour;
            Birthday = birthday;


        }
        public override string ToString()
        {
        return
        $"\nName:          {FirstName} {LastName}" +
        $"\nDate of birth: {Birthday:yyyy/MM/dd}" +
        $"\nGender:        {Gender}" +
        $"\nHair:          {Hair.HairColour}  {Hair.HairLength}" +
        $"\nEyecolour:     {EyeColour}";
        }
    }
   
}
