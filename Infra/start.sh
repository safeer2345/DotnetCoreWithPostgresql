echo "Building containers and starting up services..."

docker-compose -f docker-compose.yml up -d --remove-orphans

echo "Done!"
