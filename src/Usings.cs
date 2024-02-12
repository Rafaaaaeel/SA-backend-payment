
global using AutoMapper;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;

global using Newtonsoft.Json;

global using System.Text;
global using System.Text.Json.Serialization;
global using System.Security.Claims;
global using System.Net.Mime;
global using System.Globalization;

global using PaymentApp.Dto.Installment;
global using PaymentApp.Models;
global using PaymentApp.Interfaces;
global using PaymentApp.Repositories;

global using Sa.Payment.Api.Request;
global using Sa.Payment.Api.Response;
global using Sa.Payment.Api.IoC;
global using Sa.Payment.Api.Interface;
global using Sa.Payment.Api.Repositories;
global using Sa.Payment.Api.Context;
global using Sa.Payment.Api.Models;
global using Sa.Payment.Api.Helpers;