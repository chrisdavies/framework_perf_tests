import Ecto.Query

defmodule Web.RuzUser do
  use Web.Web, :model

  schema "users" do
    field :name, :string
    field :email, :string
    field :crypted_password, :string
    field :salt, :string
    field :time_zone, :string
    field :state, :string

    field :created_at, Ecto.DateTime
    field :updated_at, Ecto.DateTime
  end

  @required_fields ~w(email, crypted_password, state, time_zone)
  @optional_fields ~w(name, salt)

  @doc """
  Creates a changeset based on the `model` and `params`.
  If `params` are nil, an invalid changeset is returned
  with no validation performed.
  """
  def changeset(model, params \\ :empty) do
    model
    |> cast(params, @required_fields, @optional_fields)
  end

  # Fetch all active users
  def active() do
    query = from u in Web.RuzUser, where: u.state == "active", order_by: [desc: u.email]
    Web.Repo.all(query)
  end
end