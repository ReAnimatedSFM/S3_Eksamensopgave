﻿namespace App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EmployeePage), typeof(EmployeePage));
        }
    }
}