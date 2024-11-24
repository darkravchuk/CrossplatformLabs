const request = require('supertest');
const getAccessToken = require('./getAccessToken');

const API_URL = 'http://localhost:5092';

describe('CountryCodesController', () => {
    let accessToken;

    beforeAll(async () => {
        accessToken = await getAccessToken(); // Retrieve a valid access token
    });

    describe('GET /api/iso-country-codes', () => {
        it('should return a list of country codes', async () => {
            const response = await request(API_URL)
                .get('/api/iso-country-codes')
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(200);
            expect(Array.isArray(response.body)).toBe(true); // Ensure the response is an array

            if (response.body.length > 0) {
                // Check that the array contains the expected fields
                expect(response.body[0]).toHaveProperty('countryCode');
                expect(response.body[0]).toHaveProperty('countryName');
            }
        });
    });

    describe('GET /api/details', () => {
        it('should return details of a specific country by code', async () => {
            const countryCode = 'US'; // A code that exist in the database

            const response = await request(API_URL)
                .get(`/api/details?id=${countryCode}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(200);
            expect(response.body).toHaveProperty('countryCode', countryCode);
            expect(response.body).toHaveProperty('countryName');
        });

        it('should return 404 for a non-existing country code', async () => {
            const nonExistingCode = 'ZZZ'; // A code that doesn't exist in the database

            const response = await request(API_URL)
                .get(`/api/details?id=${nonExistingCode}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(404);
        });
    });
});
