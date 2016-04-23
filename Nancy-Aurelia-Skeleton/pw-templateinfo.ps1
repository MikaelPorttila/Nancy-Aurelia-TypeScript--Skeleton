[cmdletbinding()]
param()

$templateInfo = New-Object -TypeName psobject -Property @{
    Name = 'NancyAurelia'
    Type = 'ProjectTemplate'
    Description = 'Seed project for Nancy with Aurelia on the front-end'
    DefaultProjectName = 'MyProject'
    AfterInstall = {
		Update-VisualStuidoProjects -slnRoot ($SolutionRoot)
    }
}

$templateInfo | replace (
    ('NancyAureliaSkeleton', {"$ProjectName"}, {"$DefaultProjectName"}),
    ('ED638DD5-E755-4B7A-940D-5C94AB425686', {"$ProjectId"}, {[System.Guid]::NewGuid()})
)

# when the template is run any filename with the given string will be updated
$templateInfo | update-filename (
    ,('NancyAureliaSkeleton', {"$ProjectName"})
)
# excludes files from the template
$templateInfo | exclude-file 'pw-*.*','*.user','*.suo','*.userosscache','project.lock.json','*.vs*scc'
# excludes folders from the template
$templateInfo | exclude-folder '.vs','artifacts','packages','bin','obj','wwwroot/jspm_packages', 'wwwroot/dist', 'wwwroot/styles', 'node_modules'

# This will register the template with pecan-waffle
Set-TemplateInfo -templateInfo $templateInfo
