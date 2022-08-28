using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class Alumno
    {
       [Display( Name = "Nombres del Alumno" , Prompt ="ingresar nombre")]
        public string? Nombres {get;set;} 

        [Display( Name = "Apellidos del Alumno", Prompt ="ingresar apellido")]
        public string? Apellidos {get;set;}


        [Display(Name = "Cursos")]
        public curso? curso {get;set;}
        public List<curso>? CursoList {get;set;}

        }

        public class curso{

        public string? id {get;set;}

        public string? Tipo {get;set;}

        public bool active {get;set;}
        }
    
}