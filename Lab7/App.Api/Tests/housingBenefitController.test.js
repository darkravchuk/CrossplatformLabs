const request = require('supertest');
const getAccessToken = require('./getAccessToken');

const API_URL = 'http://localhost:5092'; // Update to your API's URL

describe('HousingBenefitController', () => {
    let accessToken;
    let createdHousingBenefitId; // Variable to store the ID of the created HousingBenefit

    beforeAll(async () => {
        accessToken = await getAccessToken(); // Replace with the logic to fetch an Auth0 access token
    });

    describe('DELETE /api/housing-benefits/:id', () => {
        // Before each delete test, create a new housing benefit
        beforeEach(async () => {
            const newHousingBenefit = {
                hbAddress: '123 Test Street',
                hbPostcode: 'TS12 3AB',
                hbOtherDetails: 'Details for deletion test',
            };

            const response = await request(API_URL)
                .post('/api/housing-benefits')
                .send(newHousingBenefit)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(201);
            createdHousingBenefitId = response.body.hbRecipientId; // Store the created ID for deletion
        });

        it('should delete an existing housing benefit', async () => {
            const response = await request(API_URL)
                .delete(`/api/housing-benefits/${createdHousingBenefitId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(204);

            // Verify the record no longer exists
            const verifyResponse = await request(API_URL)
                .get(`/api/housing-benefits/${createdHousingBenefitId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(verifyResponse.statusCode).toBe(404);
        });

        it('should return 404 for deleting a non-existing housing benefit', async () => {
            const nonExistingId = 9999; // An ID that doesn't exist in the database

            const response = await request(API_URL)
                .delete(`/api/housing-benefits/${nonExistingId}`)
                .set('Authorization', `Bearer ${accessToken}`);

            expect(response.statusCode).toBe(404);
        });
    });
});
