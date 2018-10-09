FROM mono:5.14.0.177 as getGendarmeAndRestorePackages

ADD . /src
WORKDIR /src

RUN curl -L -o gendarme.zip "https://github.com/downloads/spouliot/gendarme/gendarme-2.10-bin.zip"

RUN mono .nuget/nuget.exe restore -PackagesDirectory packages


FROM alpine:3.5 AS unzipGendarme

ADD . /src
WORKDIR /src
ENTRYPOINT ["src"]
RUN apk --no-cache add unzip

COPY --from=getGendarmeAndRestorePackages src/gendarme.zip gendarme.zip
RUN mkdir gendarme
RUN unzip gendarme.zip -d gendarme


FROM microsoft/dotnet:2.1.401-sdk AS build

ADD . /src
WORKDIR /src

COPY --from=getGendarmeAndRestorePackages src/packages packages

RUN dotnet clean
RUN dotnet build -c=Debug --force

RUN mkdir output
RUN dotnet build -c=Release --force -o=../output

RUN dotnet test


FROM getGendarmeAndRestorePackages as executeGendarme

COPY --from=build /src/output .
COPY --from=unzipGendarme src/gendarme gendarme

RUN mono gendarme/gendarme.exe FundamentalsTests.dll --config .gendarme/rules.xml --ignore .gendarme/default.ignore
