USE [master]
GO

/****** Object:  Database [systemObslugiKlienta]    Script Date: 2015-10-25 18:55:49 ******/
CREATE DATABASE [systemObslugiKlienta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'systemObslugiKlienta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\systemObslugiKlienta.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'systemObslugiKlienta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\systemObslugiKlienta_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [systemObslugiKlienta] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [systemObslugiKlienta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [systemObslugiKlienta] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET ARITHABORT OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [systemObslugiKlienta] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [systemObslugiKlienta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [systemObslugiKlienta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET  ENABLE_BROKER 
GO

ALTER DATABASE [systemObslugiKlienta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [systemObslugiKlienta] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [systemObslugiKlienta] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET RECOVERY FULL 
GO

ALTER DATABASE [systemObslugiKlienta] SET  MULTI_USER 
GO

ALTER DATABASE [systemObslugiKlienta] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [systemObslugiKlienta] SET DB_CHAINING OFF 
GO

ALTER DATABASE [systemObslugiKlienta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [systemObslugiKlienta] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [systemObslugiKlienta] SET  READ_WRITE 
GO

