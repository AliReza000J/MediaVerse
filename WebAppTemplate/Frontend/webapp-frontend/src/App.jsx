import { useState, useEffect } from 'react'
import UserList from './components/UserList'
import ProductList from './components/ProductList'
import { healthCheck } from './services/api'
import './App.css'

function App() {
  const [activeTab, setActiveTab] = useState('users')
  const [apiStatus, setApiStatus] = useState('checking')

  useEffect(() => {
    const checkApiHealth = async () => {
      try {
        await healthCheck();
        setApiStatus('connected');
      } catch (error) {
        console.error('API health check failed:', error);
        setApiStatus('disconnected');
      }
    };

    checkApiHealth();
  }, []);

  return (
    <div className="min-h-screen bg-gray-100">
      {/* Header */}
      <header className="bg-white shadow-sm border-b">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between items-center py-6">
            <div>
              <h1 className="text-3xl font-bold text-gray-900">
                WebApp Template
              </h1>
              <p className="text-gray-600 mt-1">
                .NET Core MVVM Backend + React Frontend
              </p>
            </div>
            
            {/* API Status Indicator */}
            <div className="flex items-center space-x-2">
              <span className="text-sm text-gray-600">API Status:</span>
              <span className={`px-3 py-1 rounded-full text-xs font-medium ${
                apiStatus === 'connected' 
                  ? 'bg-green-100 text-green-800' 
                  : apiStatus === 'disconnected'
                  ? 'bg-red-100 text-red-800'
                  : 'bg-yellow-100 text-yellow-800'
              }`}>
                {apiStatus === 'connected' ? 'Connected' : 
                 apiStatus === 'disconnected' ? 'Disconnected' : 'Checking...'}
              </span>
            </div>
          </div>
        </div>
      </header>

      {/* Navigation Tabs */}
      <nav className="bg-white border-b">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex space-x-8">
            <button
              onClick={() => setActiveTab('users')}
              className={`py-4 px-1 border-b-2 font-medium text-sm ${
                activeTab === 'users'
                  ? 'border-blue-500 text-blue-600'
                  : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
              }`}
            >
              Users
            </button>
            <button
              onClick={() => setActiveTab('products')}
              className={`py-4 px-1 border-b-2 font-medium text-sm ${
                activeTab === 'products'
                  ? 'border-blue-500 text-blue-600'
                  : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
              }`}
            >
              Products
            </button>
          </div>
        </div>
      </nav>

      {/* Main Content */}
      <main className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
        {apiStatus === 'disconnected' && (
          <div className="mb-6 bg-yellow-50 border border-yellow-200 rounded-md p-4">
            <div className="flex">
              <div className="ml-3">
                <h3 className="text-sm font-medium text-yellow-800">
                  API Connection Issue
                </h3>
                <div className="mt-2 text-sm text-yellow-700">
                  <p>
                    Cannot connect to the backend API. Make sure the .NET Core API is running on{' '}
                    <code className="bg-yellow-100 px-1 rounded">https://localhost:7138</code>
                  </p>
                </div>
              </div>
            </div>
          </div>
        )}

        {activeTab === 'users' && <UserList />}
        {activeTab === 'products' && <ProductList />}
      </main>

      {/* Footer */}
      <footer className="bg-white border-t mt-12">
        <div className="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
          <div className="text-center text-sm text-gray-500">
            <p>
              Template for collaboration between backend (.NET Core MVVM) and frontend (React + Vite) developers
            </p>
            <p className="mt-2">
              Backend API Documentation available at{' '}
              <a 
                href="https://localhost:7138" 
                target="_blank" 
                rel="noopener noreferrer"
                className="text-blue-600 hover:text-blue-500"
              >
                https://localhost:7138
              </a>
            </p>
          </div>
        </div>
      </footer>
    </div>
  )
}

export default App
