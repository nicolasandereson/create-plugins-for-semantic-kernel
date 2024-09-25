﻿#pragma warning disable SKEXP0050 
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;

string yourDeploymentName = "";
string yourEndpoint = "";
string yourApiKey = "";

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    yourDeploymentName,
    yourEndpoint,
    yourApiKey,
    "gpt-35-turbo-16k");



builder.Plugins.AddFromType<ConversationSummaryPlugin>();
var kernel = builder.Build();

string input = @"I need to prepare a vegan breakfast tomorrow. 
Please remind me to buy tofu, oats, and almond milk by 6 PM today. 
Also, suggest a spicy recipe for a quick vegan breakfast.";

var result = await kernel.InvokeAsync(
    "ConversationSummaryPlugin",
    "GetConversationActionItems",
    new() { { "input", input } });

Console.WriteLine(result);