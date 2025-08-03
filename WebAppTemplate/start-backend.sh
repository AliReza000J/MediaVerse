#!/bin/bash

echo "🚀 Starting .NET Core Backend API..."
echo "📁 Navigating to Backend directory..."

cd Backend/WebAppTemplate.Api

echo "📦 Restoring dependencies..."
dotnet restore

echo "🔥 Starting the API server..."
echo "🌐 API will be available at:"
echo "   - HTTPS: https://localhost:7138"
echo "   - HTTP:  http://localhost:5138"
echo "   - Swagger UI: https://localhost:7138"
echo ""
echo "Press Ctrl+C to stop the server"
echo "=================================="

dotnet run