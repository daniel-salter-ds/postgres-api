#!/bin/bash

cd ../src/PostgresApi || exit

# Check if migration needed
noChanges="No changes have been made to the model since the last migration."
if dotnet ef migrations has-pending-model-changes | grep -q "$noChanges"; then
  echo "No schema changes detected. Exiting..."
  exit 0
fi
echo "Schema changes detected. Proceeding..."

# Check if a migration name was provided
if [ -z "$1" ]; then
  echo "Error: Migration name is required."
  echo "Usage: ./migrate.sh <MigrationName>"
  exit 1
fi

# Add migration
echo "Adding migration: $1"
dotnet ef migrations add "$1"

# Update database
echo "Updating database with new migration..."
dotnet ef database update

echo "Migration and database update complete."