global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using System.Text.Json.Serialization;
global using System.Security.Claims;
global using System.Net.Mime;
global using System.Globalization;

global using Sa.Payment.Api.Request;
global using Sa.Payment.Api.Response;
global using Sa.Payment.Api.IoC;
global using Sa.Payment.Api.Interface;
global using Sa.Payment.Api.Repositories;
global using Sa.Payment.Api.Context;
global using Sa.Payment.Api.Models;
global using Sa.Payment.Api.Extensions;
global using Sa.Core.ErrorHandling.Exceptions;
global using Sa.Core.Managers;
global using Sa.Core.Configurations;
global using Sa.Payment.Api;
global using Sa.Core.Extensions;

// TODO - REFATORAR
global using PaymentApp.Dto.Installment;