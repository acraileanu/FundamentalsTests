FROM mono:5.14.0.177 AS packagesRestore

ADD . /src
WORKDIR /src

RUN mono nuget.exe restore -PackagesDirectory packages

FROM microsoft/dotnet:2.1.401-sdk

ADD . /src
WORKDIR /src

COPY --from=packagesRestore src/packages packages

RUN dotnet clean
RUN dotnet build -c=Debug --force
RUN dotnet build -c=Release --force

RUN dotnet test
