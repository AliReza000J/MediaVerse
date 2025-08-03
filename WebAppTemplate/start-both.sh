#!/bin/bash

echo "🚀 Starting Full-Stack WebApp Template..."
echo "This will start both Backend (.NET Core) and Frontend (React + Vite)"
echo ""

# Function to handle cleanup
cleanup() {
    echo ""
    echo "🛑 Shutting down servers..."
    kill $BACKEND_PID $FRONTEND_PID 2>/dev/null
    exit 0
}

# Set trap to cleanup on script exit
trap cleanup SIGINT SIGTERM

echo "📡 Starting Backend API..."
cd Backend/WebAppTemplate.Api
dotnet restore > /dev/null 2>&1
dotnet run > backend.log 2>&1 &
BACKEND_PID=$!

echo "⏳ Waiting for backend to start..."
sleep 5

echo "🎨 Starting Frontend..."
cd ../../Frontend/webapp-frontend
npm install > /dev/null 2>&1
npm run dev > frontend.log 2>&1 &
FRONTEND_PID=$!

echo ""
echo "✅ Both servers are starting up!"
echo "🌐 Services will be available at:"
echo "   - Backend API: https://localhost:7138"
echo "   - Frontend:    http://localhost:5173"
echo ""
echo "📝 Logs:"
echo "   - Backend:  Backend/WebAppTemplate.Api/backend.log"
echo "   - Frontend: Frontend/webapp-frontend/frontend.log"
echo ""
echo "Press Ctrl+C to stop both servers"
echo "=================================="

# Wait for processes
wait $BACKEND_PID $FRONTEND_PID