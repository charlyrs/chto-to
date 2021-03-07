using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace HelloKitty.Models{
    public class RegistrationViewModel{
        private static int count=2;
        public int Id { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set;}
        public string Name{ get; set; }

        // public RegistrationViewModel(){
        //     count++;
        //     Id = count;
        // }
        
    }

    
}