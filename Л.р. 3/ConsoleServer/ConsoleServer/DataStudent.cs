﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class DataStudent
    {
        public static List<Student> students = new List<Student>()
        {
            new Student("Екатерина","Внеземная","16ИТ-2"),
            new Student("Александр","Малик","17ИТ-1"),
            new Student("Антон","Моцук","16БД-2"),
            new Student("Вадим","Логут","16С-1"),
            new Student("Кирилл","Кривецкий","18ИТ-2"),
            new Student("Мария","Лемешевская","19ФИК-2")
        };
    }
}
