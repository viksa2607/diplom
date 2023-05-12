cd .. &
cd UI &
build & cd .. & cd App & dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true --self-contained true



