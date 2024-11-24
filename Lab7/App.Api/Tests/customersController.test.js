const request = require('supertest');
const getAccessToken = require('./getAccessToken');

const API_URL = 'http://localhost:5092'; // Update to your API's URL

describe('CustomersController', () => {
    let accessToken;

    beforeAll(async () => {
        accessToken = await getAccessToken(); // Retrieve a valid access token
    });

    describe('GET /api/customers', () => {
        it('should return a list of customers with their addresses', async () => {
            const response = await request(API_URL)
                .get('/api/customers')
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(200);
            expect(Array.isArray(response.body)).toBe(true); // Ensure the response is an array

            if (response.body.length > 0) {
                // Check that the array contains the expected fields
                expect(response.body[0]).toHaveProperty('mdmCustomerId');
                expect(response.body[0]).toHaveProperty('patAddress');
                expect(response.body[0].patAddress).toHaveProperty('addressLine1');
                expect(response.body[0].patAddress).toHaveProperty('postcode');
            }
        });
    });

    describe('GET /api/customers/:id', () => {
        it('should return details of a specific customer by ID', async () => {
            const customerId = 1; // Replace with a valid customer ID from your database

            const response = await request(API_URL)
                .get(`/api/customers/${customerId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(200);
            expect(response.body).toHaveProperty('mdmCustomerId', customerId);
            expect(response.body).toHaveProperty('patAddress');
            expect(response.body.patAddress).toHaveProperty('addressLine1');
            expect(response.body.patAddress).toHaveProperty('postcode');
        });

        it('should return 404 for a non-existing customer', async () => {
            const nonExistingId = 9999; // Replace with an ID that doesn’t exist

            const response = await request(API_URL)
                .get(`/api/customers/${nonExistingId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(404);
        });
    });
});
