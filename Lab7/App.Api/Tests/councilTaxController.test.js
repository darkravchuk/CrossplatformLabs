const request = require('supertest');
const getAccessToken = require('./getAccessToken');

const API_URL = 'http://localhost:5092';

describe('CouncilTaxController', () => {
    let accessToken;

    beforeAll(async () => {
        accessToken = await getAccessToken();
    });

    describe('GET /api/council-taxes', () => {
        it('should return a list of council taxes', async () => {
            const response = await request(API_URL)
                .get('/api/council-taxes')
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(200);
            expect(Array.isArray(response.body)).toBe(true);
            if (response.body.length > 0) {
                expect(response.body[0]).toHaveProperty('ctResidentId');
                expect(response.body[0]).toHaveProperty('ctAddressLine1');
                expect(response.body[0]).toHaveProperty('ctCityTown');
                expect(response.body[0]).toHaveProperty('ctPostcode');
            }
        });
    });

    describe('GET /api/council-taxes/:id', () => {
        it('should return details of a specific council tax by ID', async () => {
            const councilTaxId = 1;

            const response = await request(API_URL)
                .get(`/api/council-taxes/${councilTaxId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(200);
            expect(response.body).toHaveProperty('ctResidentId', councilTaxId);
            expect(response.body).toHaveProperty('ctAddressLine1');
            expect(response.body).toHaveProperty('ctCityTown');
            expect(response.body).toHaveProperty('ctPostcode');
        });

        it('should return 404 for a non-existing council tax', async () => {
            const nonExistingId = 9999;

            const response = await request(API_URL)
                .get(`/api/council-taxes/${nonExistingId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(404);
        });
    });
});
