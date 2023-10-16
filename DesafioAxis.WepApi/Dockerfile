#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Estagio 1 - responsavel por : Puxa a imagem do .net e expoem nas portas 80 e 443 
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Estagio 2 - Puxa imagem do SDK (Maior) - cria um novo diretorio de trabalho - executa o run e o build (algo simlar a uma automatização)
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DesafioAxis.WepApi/DesafioAxis.WepApi.csproj", "DesafioAxis.WepApi/"]
RUN dotnet restore "DesafioAxis.WepApi/DesafioAxis.WepApi.csproj"
COPY . .
WORKDIR "/src/DesafioAxis.WepApi"
RUN dotnet build "DesafioAxis.WepApi.csproj" -c Release -o /app/build

#Estagio 3 - publica o arquivo de saida
FROM build AS publish
RUN dotnet publish "DesafioAxis.WepApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

#Estagio 4 - copia os arquivos e executa o dll do programa
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioAxis.WepApi.dll"]