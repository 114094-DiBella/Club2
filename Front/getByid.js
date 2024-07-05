document.getElementById('getUserBtn').addEventListener('click', async function() {
    const userId = document.getElementById('userId').value;
    try {
      const response = await fetch('https://localhost:5001/api/Socio/GetById', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'id': userId
        }
      });

      if (response.ok) {
        const user = await response.json();
        document.getElementById('userInfo').innerHTML = `<pre>${JSON.stringify(user, null, 2)}</pre>`;
      } else {
        document.getElementById('userInfo').innerHTML = 'Usuario no encontrado';
      }
    } catch (error) {
      console.error('Error:', error);
    }
  });