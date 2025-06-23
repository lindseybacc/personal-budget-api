// Import necessary libraries
const express = require ('express');
const http = require ('http');
const cors = require ('cors');
const { Server } = require ('socket.io');

// Create an express app
const app = express();

// Enable CORS so frontend can talk to backend
app.use(cors());

// Allow Express to parse JSON data sent by clients
app.use(express.json());
app.use(express.static('public'));

// Create HTTP server using express app
const server = http.createServer(app);

// Create Socket.IO server attached to HTTP server
const io = new Server(server, {
    cors: {origin: '*'}
});

// Listen for client connections
io.on('connection', (socket) => {  
  console.log('New client connected', socket.id);

  // Handle user joining a specific budget room
  socket.on('joinBudget', (budgetId) => {  
    socket.join(budgetId);  
    console.log(`User joined budget room: ${budgetId}`);  
  });

  // Handle transaction updates and broadcast to room
  socket.on('updateTransaction', ({ budgetId, transaction }) => {  
    socket.to(budgetId).emit('transactionUpdated', transaction);  
  });

  // Log disconnects
  socket.on('disconnect', () => {  
    console.log('Client disconnected', socket.id);  
  });  
});

// Start the server on port 4000 (or environment port)
const PORT = process.env.PORT || 4000;  
server.listen(PORT, () => console.log(`Server running on port ${PORT}`));