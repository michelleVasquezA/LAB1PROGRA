using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;

namespace webapp.Controllers
{
   
    public class AlumnoController : Controller
    {
        private readonly ILogger<AlumnoController> _logger;

        public AlumnoController(ILogger<AlumnoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
         public IActionResult Registrar(Alumno objAlu)    
        {
            string? nombre=null,apellido=null;
            double total=0.0,IGV=0.0,costoCurso=0.0,j=0;
            nombre=objAlu.Nombres;
            apellido=objAlu.Apellidos;

            string listacurso=null;
            List<curso> cur = objAlu.CursoList;

              for (int i = 0; i<cur.Count; i++){
                if(cur[i].active == true){
                    listacurso += cur[i].Tipo+ " ";
                    j++;
                }
                
            } 
                costoCurso=j*300;
                IGV=0.18*costoCurso;
                total=costoCurso+IGV;

            ViewData["Message"] =  "Alumno(a): "+nombre + " " + apellido;
            ViewData["Message1"] = "Curso/Cursos: " + listacurso;
            ViewData["Message2"] = "Total Curso: " + costoCurso; 
            ViewData["Message3"] = "IGV: " + IGV; 
            ViewData["Message4"] = "Total: " + total; 

            return View("calcular");
        }

        [HttpGet]
         public IActionResult Index(Alumno objAlu){

                var curso = new Alumno{

                    CursoList = new List<curso>{
                    new curso{id="1" , Tipo = "Programacion I"}, 
                    new curso{id="2" , Tipo = "Introducción a la Programación"},
                    new curso{id="3" , Tipo = "Teoría Diseño y Base de datos"}

                    }

                };


            return View(curso);

         }    
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}