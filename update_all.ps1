# Yes I like to live dangerously 😎
fastmod ">net9\.0<" ">net10.0<" --glob *.csproj --accept-all
Get-ChildItem |
    Where-Object { $_.PSIsContainer } |
    ForEach {
        pushd $_.FullName
        Get-ChildItem *.csproj | ForEach {
        "dotnet run --configuration Release $($_.Name)"
         if (!(Test-Path *.sln)) {
            dotnet new sln
            dotnet sln add $_.Name
        }

        dotnet run --configuration Release $($_.Name)
        ..\update_results.ps1
        }

        popd
    }