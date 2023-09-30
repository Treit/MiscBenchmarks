$pwd = $PSScriptRoot
$tool = Join-Path $pwd "tools\UpdateResults\bin\Debug\net7.0\UpdateResults.exe"
if (!(Test-Path $tool)) 
{
    $toolDir = Join-Path $pwd "tools\UpdateResults"
    pushd $toolDir
    pwd
    dotnet build
    popd
}

& $tool $args


