using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }     
        public DateTime UpdatedDateTime { get; set; }       
        public DateTime CreatedDateTime { get; set; }
        public Guid? CreatedUserId { get; set; }        
        public Guid? UpdatedUserId { get; set; }    
        public User? CreatedUser { get; set; }
        public User? UpdatedUser { get; set; }
    }
}
