# Railway.Functional

![Build Status](https://img.shields.io/badge/build-passing-brightgreen) ![NuGet Version](https://img.shields.io/badge/nuget-v1.0.0-blue) ![License](https://img.shields.io/badge/license-MIT-green)

**Railway.Functional** is a lightweight, zero-dependency .NET library that implements the **Railway Oriented Programming (ROP)** pattern.

It eliminates "Try/Catch Hell" by treating errors as first-class citizens. Instead of throwing exceptions for control flow, your methods return a `Result` object that represents either **Success** (with a value) or **Failure** (with an error message).

## 🚀 Why use this?

* **Type Safety:** No more guessing if a method throws an exception. The return signature tells you everything.
* **Fluent API:** Chain operations cleanly using `.OnSuccess()` and `.OnFail()`.
* **Immutability:** Results are immutable and thread-safe.
* **Zero Magic:** No hidden reflection, just pure C# architecture.

## 📦 Installation

```bash
dotnet add package Railway.Functional