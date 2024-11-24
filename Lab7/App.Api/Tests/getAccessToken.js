const axios = require('axios');

const AUTH0_DOMAIN = 'https://dev-zr1iopf4dntu7y1o.us.auth0.com'; // Auth0 domain
const CLIENT_ID = 'mmABop6oCpx5CbREWg5gaimViHLvMjai'; // Auth0 Client ID
const CLIENT_SECRET = '2ZjxwyinhiYP0nA_KDqUFrv89zk-Fh2wv9COu_BKuo6TmocSFkJQ-pG0A15QSu4H'; // Auth0 Client Secret
const AUDIENCE = 'lab6Api'; // The API audience (identifier)

async function getAccessToken() {
    try {
        const response = await axios.post(`${AUTH0_DOMAIN}/oauth/token`, {
            client_id: CLIENT_ID,
            client_secret: CLIENT_SECRET,
            audience: AUDIENCE,
            grant_type: 'client_credentials',
        });

        return response.data.access_token;
    } catch (error) {
        console.error('Error fetching access token from Auth0:', error.response?.data || error.message);
        throw new Error('Failed to fetch access token');
    }
}

module.exports = getAccessToken;
