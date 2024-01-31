# back-end
Za pokretanje ovog dela prvo se u bazi kreira sema CREATE SCHEMA "stakeholders";

Potom pokrenuti migracije u Visual Studiu Add-Migration -Name Init -Context StakeholdersContext -Project Explorer.Stakeholders.Infrastructure -StartupProject Explorer.API
Update-Database -Context StakeholdersContext -Project Explorer.Stakeholders.Infrastructure -StartupProject Explorer.API

Na kraju kliknuti na IIS Express za pokretanje u Visual Studiu
