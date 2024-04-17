const { MongoClient } = require("mongodb");
const ObjectID = require("mongodb").ObjectId;
const { resposnes } = require('../responses/response');

const uri = "mongodb://127.0.0.1";
const dbName = "testDB";


async function checkCollectionExistence(collectionName) {
  console.log("checkCollectionExistence");
  const client = new MongoClient(uri);

  try {
      await client.connect();
      const database = client.db(dbName);
      const collections = await database.listCollections().toArray();
      const collectionExists = collections.some(collection => collection.name === collectionName);

      if (collectionExists) {
          console.log(`Collection '${collectionName}' exists.`);
      } else {
          console.log(`Collection '${collectionName}' does not exist.`);
      }
      return collectionExists;
  } catch (error) {
      console.error('Error checking collection existence:', error);
      return false;
  } finally {
      await client.close();
  }
}

async function createCollection(collectionName) {
  const client = new MongoClient(uri);
  try {
    await client.connect();
    const database = client.db(dbName);
    const result = await database.createCollection(collectionName);
    console.log(`Collection '${collectionName}' created successfully.`);
    return new resposnes(200, "Created Successfully", result);
  } catch (error) {
    console.error("Error creating collection:", error);
    return new resposnes(400, "Something went wrong", result);
  } finally {
    await client.close();
  }
}

async function saveData(dataToSave, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const result = await collection.insertOne(dataToSave);
    console.log(`Data saved successfully with _id: ${result.insertedId}`);
    return new resposnes(200, "Created Successfully", result.insertedId);
  } catch (error) {
    console.error("Error saving data:", error);
    return new resposnes(400, "Something went wrong", null);
  } finally {
    await client.close();
  }
}

async function updateData(filter, dataToSave, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const updateOperation = {
      $set: dataToSave,
    };
    const result = await collection.updateOne(filter, updateOperation);
    console.log(`Data updated successfully with _id: ${result.insertedId}`);
    return new resposnes(200, "Updated Successfully", result.insertedId);
  } catch (error) {
    console.error("Error saving data:", error);
    return new resposnes(400, "Something went wrong", null);
  } finally {
    await client.close();
  }
}

async function getData(query, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const data = await collection.find(query).toArray();

    console.log("Data retrieved successfully:");
    console.log(data);
    return new resposnes(200, "Success!", data);
  } catch (error) {
    console.error("Error retrieving data:", error);
    return new resposnes(400, "Something went wrong", null);
  } finally {
    await client.close();
  }
}

async function deleteData(query, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const result = await collection.deleteOne(query);
    console.log(`Deleted ${result.deletedCount} document(s)`);
    return new resposnes(200, "Created Successfully", null);
  } catch (error) {
    console.error("Error deleting data:", error);
    return new resposnes(400, "Something went wrong", null);
  } finally {
    await client.close();
  }
}

module.exports = {
  checkCollectionExistence: checkCollectionExistence,
  createCollection: createCollection,
  saveData: saveData,
  updateData: updateData,
  getData: getData,
  deleteData: deleteData,
};
