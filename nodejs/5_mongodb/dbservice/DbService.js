const { MongoClient, ObjectID } = require("mongodb");
const { resposnes } = require('../responses/response');

const uri = "mongodb://127.0.0.1";
const dbName = "testDB";

async function createCollection(collectionName) {
  const client = new MongoClient(uri);
  try {
    await client.connect();
    const database = client.db(dbName);
    await database.createCollection(collectionName);
    console.log(`Collection '${collectionName}' created successfully.`);
    return new resposnes(200, "Created Successfully", null);
  } catch (error) {
    console.error("Error creating collection:", error);
    return new resposnes(400, "Something went wrong", null);
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

async function updateData(dataToSave, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const filter = { _id: new ObjectID(id) };
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

async function getData(_query, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const query = _query;
    const data = await collection.find(query).toArray();

    console.log("Data retrieved successfully:");
    console.log(data);
    return new resposnes(200, "Retrieved Successfully", data);
  } catch (error) {
    console.error("Error retrieving data:", error);
    return new resposnes(400, "Something went wrong", null);
  } finally {
    await client.close();
  }
}

async function deleteData(ID, collectionName) {
  const client = new MongoClient(uri);

  try {
    await client.connect();
    const database = client.db(dbName);
    const collection = database.collection(collectionName);
    const deletionCriteria = { _id: new ObjectID(ID) };
    const result = await collection.deleteOne(deletionCriteria);
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
  createCollection: createCollection,
  saveData: saveData,
  updateData: updateData,
  getData: getData,
  deleteData: deleteData,
};
